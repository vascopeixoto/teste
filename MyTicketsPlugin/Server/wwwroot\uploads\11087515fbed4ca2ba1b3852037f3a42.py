import json
import requests
import pandas as pd
import numpy as np
import pytz
from datetime import datetime
from dateutil import relativedelta
from dateutil.relativedelta import relativedelta as rd
from pymongo import MongoClient

# conectar a base de dados
client = MongoClient('localhost', 27017)
db = client['madetolast']
collection = db['deals']

deals1 = requests.get('https://powerbi.erp24.pt/Crm/DealHistory/14/m0Fh0')
my_string1 = deals1.content.decode('utf-8')
data1 = json.loads (my_string1)
deals = pd.DataFrame (data1)
id = int(deals['ID'][-1:])
n,stage,type_id,semantic= datetime.strptime('3000/1/1',"%Y/%m/%d"),"NEW","2","P"
Deals=pd.DataFrame()
for index, row in deals.iterrows():
    end = row['CREATED_TIME']
    end = datetime.strptime(end,"%Y-%m-%dT%H:%M:%S")
    dict1 = {'ID': row['ID'], 'TYPE_ID': row['TYPE_ID'], 'OWNER_ID':row['OWNER_ID'], 'CREATED_TIME':end, 'CATEGORY_ID':row['CATEGORY_ID'], 'STAGE_SEMANTIC_ID':row['STAGE_SEMANTIC_ID'], 'STAGE_ID':row['STAGE_ID']}
    df2=pd.DataFrame(dict1,index=[len(Deals)])
    Deals=pd.concat([Deals,df2], ignore_index=True)
    Deals.reset_index()
    
Deals_Updated=Deals
for x in Deals['OWNER_ID']:
    owner_x = Deals.loc[Deals['OWNER_ID'] == x]
    num=len(owner_x)
    owner = Deals_Updated.loc[Deals_Updated['OWNER_ID'] == x]
    if len(owner)<=num:
        for index, row in owner_x.iterrows():
            start = n
            end = row['CREATED_TIME']
            aux = relativedelta.relativedelta(end,start)
            month = aux.months + (aux.years * 12)
            m = month + 1
            n = end
            if month > 0:
                for i in range(1,m):
                    f=rd(months=+i)
                    future_date=f+start
                    id+=1
                    dict1 = {'ID': id, 'TYPE_ID': type_id, 'OWNER_ID':row['OWNER_ID'], 'CREATED_TIME':future_date, 'CATEGORY_ID':row['CATEGORY_ID'], 'STAGE_SEMANTIC_ID':semantic, 'STAGE_ID':stage}
                    df2=pd.DataFrame(dict1,index=[len(Deals_Updated)])
                    Deals_Updated=pd.concat([Deals_Updated,df2], ignore_index=True)
                    Deals_Updated.reset_index()
            stage=row['STAGE_ID']
            type_id=row['TYPE_ID']
            semantic=row['STAGE_SEMANTIC_ID']
sorted_df=Deals_Updated.sort_values(by=['CREATED_TIME'])
n,stage,type_id,semantic= datetime.strptime('3000/1/1',"%Y/%m/%d"),"NEW","2","P"
for x in sorted_df['OWNER_ID']:
    owner = Deals_Updated.loc[Deals_Updated['OWNER_ID'] == x]
    owner_z = sorted_df.loc[sorted_df['OWNER_ID'] == x]
    num=len(owner)
    n1=len(owner_z)
    if "C6:WON" not in owner_z.values:
        if "C6:LOSE" not in owner_z.values:
            if "C6:APOLOGY" not in owner_z.values:
                if "C4:WON" not in owner_z.values:
                    if "C4:LOSE" not in owner_z.values:
                        if "C4:APOLOGY" not in owner_z.values:          
                            if "C4:14" not in owner_z.values:
                                if "C4:15" not in owner_z.values:
                                    if "C4:16" not in owner_z.values:
                                        if "C4:17" not in owner_z.values:
                                            if "C4:18" not in owner_z.values:
                                                if "C6:14" not in owner_z.values:
                                                    if "C6:18" not in owner_z.values:
                                                        if "C6:17" not in owner_z.values:
                                                            if "C6:15" not in owner_z.values:
                                                                if "WON" not in owner_z.values:
                                                                    if "LOSE" not in owner_z.values:
                                                                        if "1" not in owner_z.values:
                                                                            if "14" not in owner_z.values:
                                                                                if "15" not in owner_z.values:
                                                                                    if "16" not in owner_z.values:
                                                                                        if "18" not in owner_z.values:
                                                                                            if "17" not in owner_z.values:
                                                                                                if "C22:WON" not in owner_z.values:
                                                                                                    if "C22:LOSE" not in owner_z.values:
                                                                                                        if "C22:APOLOGY" not in owner_z.values:
                                                                                                            if "C47:WON" not in owner_z.values:
                                                                                                                if "C47:LOSE" not in owner_z.values:
                                                                                                                    if "C18:13" not in owner_z.values:
                                                                                                                        if "C47:APOLOGY" not in owner_z.values:
                                                                                                                            if "C18:WON" not in owner_z.values:
                                                                                                                                if "C18:LOSE" not in owner_z.values:
                                                                                                                                    if "C18:APOLOGY" not in owner_z.values:
                                                                                                                                        if "C18:14" not in owner_z.values:
                                                                                                                                            if "C18:15" not in owner_z.values:
                                                                                                                                                if "C18:16" not in owner_z.values:
                                                                                                                                                    if "C18:17" not in owner_z.values:
                                                                                                                                                        if "C24:WON" not in owner_z.values:
                                                                                                                                                            if "C24:LOSE" not in owner_z.values:
                                                                                                                                                                if "C24:APOLOGY" not in owner_z.values:
                                                                                                                                                                    if "C26:APOLOGY" not in owner_z.values:
                                                                                                                                                                        if "C26:WON" not in owner_z.values:
                                                                                                                                                                            if "C26:LOSE" not in owner_z.values:
                                                                                                                                                                                if "C28:WON" not in owner_z.values:
                                                                                                                                                                                    if "C28:LOSE" not in owner_z.values:
                                                                                                                                                                                        if "C28:APOLOGY" not in owner_z.values:
                                                                                                                                                                                            if "C30:WON" not in owner_z.values:
                                                                                                                                                                                                if "C30:LOSE" not in owner_z.values:
                                                                                                                                                                                                    if "C30:APOLOGY" not in owner_z.values:
                                                                                                                                                                                                        if "C45:WON" not in owner_z.values:
                                                                                                                                                                                                            if "C45:LOSE" not in owner_z.values:
                                                                                                                                                                                                                if "C45:APOLOGY" not in owner_z.values:
                                                                                                                                                                                                                    if "C45:UC_7FWE1H" not in owner_z.values:
                                                                                                                                                                                                                        if "C45:UC_XZW1D8" not in owner_z.values:
                                                                                                                                                                                                                            if "C45:UC_ZKWFED" not in owner_z.values:
                                                                                                                                                                                                                                if "C45:UC_ZNZLQL" not in owner_z.values:
                                                                                                                                                                                                                                    if "C45:UC_C5IAXY" not in owner_z.values:
                                                                                                                                                                                                                                        if "C2:APOLOGY" not in owner_z.values:
                                                                                                                                                                                                                                            if "C2:15" not in owner_z.values:
                                                                                                                                                                                                                                                if "C2:WON" not in owner_z.values:
                                                                                                                                                                                                                                                    if "C2:LOSE" not in owner_z.values:
                                                                                                                                                                                                                                                        if "C2:16" not in owner_z.values:
                                                                                                                                                                                                                                                            if "C2:17" not in owner_z.values:
                                                                                                                                                                                                                                                                if "C2:18" not in owner_z.values:
                                                                                                                                                                                                                                                                    if "C2:14" not in owner_z.values:
                                                                                                                                                                                                                                                                        if n1<=num:
                                                                                                                                                                                                                                                                            last=owner_z.iloc[-1:]
                                                                                                                                                                                                                                                                            start = datetime.today()
                                                                                                                                                                                                                                                                            end = last['CREATED_TIME'].values[0]
                                                                                                                                                                                                                                                                            if isinstance(end, np.datetime64):
                                                                                                                                                                                                                                                                                timestamp = end.astype(datetime)
                                                                                                                                                                                                                                                                                end = pd.to_datetime(timestamp, utc=True)
                                                                                                                                                                                                                                                                                end =end.to_pydatetime()
                                                                                                                                                                                                                                                                            start = pytz.utc.localize(start)
                                                                                                                                                                                                                                                                            aux = relativedelta.relativedelta(start.replace(tzinfo=None),end.replace(tzinfo=None))
                                                                                                                                                                                                                                                                            month = aux.months + (aux.years * 12)
                                                                                                                                                                                                                                                                            m = month + 1
                                                                                                                                                                                                                                                                            n = end
                                                                                                                                                                                                                                                                            if month > 0:
                                                                                                                                                                                                                                                                                for i in range(1,m): 
                                                                                                                                                                                                                                                                                    f = rd(months =+ i)
                                                                                                                                                                                                                                                                                    future_date = f + end
                                                                                                                                                                                                                                                                                    id += 1
                                                                                                                                                                                                                                                                                    dict1 = {'ID': id, 'TYPE_ID': last['TYPE_ID'], 'OWNER_ID':last['OWNER_ID'], 'CREATED_TIME':future_date, 'CATEGORY_ID':last['CATEGORY_ID'], 'STAGE_SEMANTIC_ID':last['STAGE_SEMANTIC_ID'], 'STAGE_ID':last['STAGE_ID']}
                                                                                                                                                                                                                                                                                    df2 = pd.DataFrame(dict1)
                                                                                                                                                                                                                                                                                    sorted_df = pd.concat([sorted_df,df2], ignore_index = True)
                                                                                                                                                                                                                                                                                    sorted_df.reset_index()
                                                                                                                                                                                                                                                                            stage = last['STAGE_ID']
                                                                                                                                                                                                                                                                            type_id = last['TYPE_ID']
                                                                                                                                                                                                                                                                            semantic = last['STAGE_SEMANTIC_ID']
del deals
del Deals
del Deals_Updated
del df2
del last
del owner
del owner_x
del owner_z


your_json = sorted_df.to_json(orient = 'records')
data = json.loads(your_json)
arr = np.array(data) 
d = dict(enumerate(arr.flatten(), 1))
print(d)
keys_values = d.items()
new_d = {str(key): value for key, value in keys_values}

collection.update_many({}, {"$set": new_d})#, upsert=False)

client.close()