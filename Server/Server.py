from collections import defaultdict

import random
import grpc
import os
import gRPC_implementation.DBmanagement_pb2 as pb2
import gRPC_implementation.DBmanagement_pb2_grpc as pb2_grpc
import google.protobuf.json_format as jf
from concurrent import futures


class DBmanager(pb2_grpc.DBmanagementServicer):
    def GetID(self, request, context):
        return pb2.ClientDataLookupModel(client_id=random.randint())
    
    def GetData(self, request, context):
        result = pb2.ClientDataModel()
        result.client_id = request.client_id
        
        base_dir = os.path.join(os.path.dirname(os.path.realpath(__file__)), "Data", str(request.client_id))
        os.makedirs(base_dir, exist_ok=True)
        
        db_files = [f for f in os.listdir(base_dir) if f.endswith(".json")]
        for db_file in db_files:
            with open(os.path.join(base_dir, db_file), 'r') as file:
                data = file.read()
                db = pb2.DataBaseSO()
                jf.Parse(data, db)
                result.bases.append(db)
        return result

    def SaveData(self, request, context):
        try:
            base_dir = os.path.join(os.path.dirname(os.path.realpath(__file__)), "Data")
            os.makedirs(base_dir, exist_ok=True)
            client_dir = os.path.join(base_dir, str(request.client_id))
            os.makedirs(client_dir, exist_ok=True)

            for base in request.bases:

                json_data = jf.MessageToJson(base)
                with open(os.path.join(client_dir, base.name + ".json"), 'w') as file:
                    file.write(json_data)

            return pb2.DataSavedResponce(success=True)
        except Exception as ex:
            print (ex)
            return pb2.DataSavedResponce(success=False, message=str(ex))



class OperationsManager(pb2_grpc.OperationsManagementServicer):
    def PerformFullMultiplication(self, request, context):
        table1 = request.first
        table2 = request.second

        dt = pb2.DataTableSO(name="result", id=-1, columns=[], rows=[])

        for col in table1.columns:
            dt.columns.append(col)

        for col in table2.columns:
            dt.columns.append(col)

        for r1 in table1.rows:
            for r2 in table2.rows:
                row = pb2.DataRowSO(data=[])

                for data1 in r1.data:
                    row.data.append(data1)

                for data2 in r2.data:
                    row.data.append(data2)

                dt.rows.append(row)

        return dt

#================================== MAIN ========================
if __name__ == '__main__':
    print("Python gRPC Server Version:", grpc.__version__)

    server = grpc.server(futures.ThreadPoolExecutor(max_workers=10))
    
    pb2_grpc.add_DBmanagementServicer_to_server(DBmanager(), server)
    pb2_grpc.add_OperationsManagementServicer_to_server(OperationsManager(), server)

    server.add_insecure_port('[::]:7018')
    server.start()
    print("Server started on port 7018...")
    server.wait_for_termination()