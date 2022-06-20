import json
import requests
import pandas as pd
import numpy as np
import pytz
from datetime import datetime
from dateutil import relativedelta
from dateutil.relativedelta import relativedelta as rd
leads1 = requests.get('https://powerbi.erp24.pt/Crm/LeadHistory/8/u2Lou')
my_string1 = leads1.content.decode('utf-8')
data1 = json.loads (my_string1)
leads = pd.DataFrame (data1)

id = int(leads['ID'][-1:])
n,status,type_id,semantic= datetime.strptime('3000/1/1',"%Y/%m/%d"),"NEW","2","P"
Leads=pd.DataFrame()
for index, row in leads.iterrows():
    end = row['CREATED_TIME']
    end = datetime.strptime(end,"%Y-%m-%dT%H:%M:%S")
    dict1 = {'ID': row['ID'], 'TYPE_ID': row['TYPE_ID'], 'OWNER_ID':row['OWNER_ID'], 'CREATED_TIME':end, 'STATUS_SEMANTIC_ID':row['STATUS_SEMANTIC_ID'], 'STATUS_ID':row['STATUS_ID']}
    df2=pd.DataFrame(dict1,index=[len(Leads)])
    Leads=pd.concat([Leads,df2], ignore_index=True)
    Leads.reset_index()
    
Leads_Updated=Leads
for x in Leads['OWNER_ID']:
    owner_x = Leads.loc[Leads['OWNER_ID'] == x]
    num=len(owner_x)
    owner = Leads_Updated.loc[Leads_Updated['OWNER_ID'] == x]
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
                    dict1 = {'ID': id, 'TYPE_ID': type_id, 'OWNER_ID':row['OWNER_ID'], 'CREATED_TIME':future_date, 'STATUS_SEMANTIC_ID':semantic, 'STATUS_ID':status}
                    df2=pd.DataFrame(dict1,index=[len(Leads_Updated)])
                    Leads_Updated=pd.concat([Leads_Updated,df2], ignore_index=True)
                    Leads_Updated.reset_index()
            status=row['STATUS_ID']
            type_id=row['TYPE_ID']
            semantic=row['STATUS_SEMANTIC_ID']
sorted_df=Leads_Updated.sort_values(by=['CREATED_TIME'])
n,status,type_id,semantic= datetime.strptime('3000/1/1',"%Y/%m/%d"),"NEW","2","P"
for x in sorted_df['OWNER_ID']:
    owner = Leads_Updated.loc[Leads_Updated['OWNER_ID'] == x]
    owner_z = sorted_df.loc[sorted_df['OWNER_ID'] == x]
    num=len(owner)
    n1=len(owner_z)
    if "JUNK" not in owner_z.values:
        if "8" not in owner_z.values:
            if "CONVERTED" not in owner_z.values:
                if "12" not in owner_z.values:
                    if "13" not in owner_z.values:
                        if "14" not in owner_z.values:
                            if n1<=num:
                                last=owner_z.iloc[-1:]
                                start = datetime.today()
                                end = last['CREATED_TIME'].values[0]
                                if isinstance(end, np.datetime64):
                                    timestamp = end.astype(datetime)
                                    end = pd.to_datetime(timestamp, utc=True)
                                    end =end.to_pydatetime()
                                start = pytz.utc.localize(start)
                                end=end.replace(day=1)
                                aux = relativedelta.relativedelta(start.replace(tzinfo=None),end.replace(tzinfo=None))
                                month = aux.months + (aux.years * 12)
                                m = month + 1
                                n = end
                                if month > 0:
                                    for i in range(1,m): 
                                        f = rd(months =+ i)
                                        future_date = f + end
                                        id += 1
                                        dict1 = {'ID': id, 'TYPE_ID': last['TYPE_ID'], 'OWNER_ID':last['OWNER_ID'], 'CREATED_TIME':future_date, 'STATUS_SEMANTIC_ID':last['STATUS_SEMANTIC_ID'], 'STATUS_ID':last['STATUS_ID']}
                                        df2 = pd.DataFrame(dict1)
                                        sorted_df = pd.concat([sorted_df,df2], ignore_index = True)      
                                        sorted_df.reset_index()
                                stage = last['STATUS_ID']
                                type_id = last['TYPE_ID']
                                semantic = last['STATUS_SEMANTIC_ID']
del leads
del Leads
del Leads_Updated
del df2
del last
del owner
del owner_x
del owner_z
sorted_df['CREATED_TIME']=sorted_df['CREATED_TIME'].astype(str)
data=sorted_df.to_dict(orient='records')