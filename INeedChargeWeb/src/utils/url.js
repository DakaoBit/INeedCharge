export function getApiUrl (apicode) {

    const host = window.location.origin;

    const env = {
        "http://localhost:5173":"http://localhost:5198", 
        "http://127.0.0.1:5173":"http://127.0.0.1:5198",
    }

    const urlMap = new Map([
        //signalR用url
 
        //API
        ["Operator", env[host]+ "/data/GetOneOperator"],
        ["SelectStation", env[host]+ "/data/GetSelectStationList"],
        ["Station", env[host]+ "/data/GetStationList"],
 

    ])

    return urlMap.get(apicode);
}

export async function fetchGet(apiUrl,params){
    return new Promise(async(resolve,reject) => {
        let paramsStr = new URLSearchParams({
            ...params
        })
        apiUrl = apiUrl + "?" + paramsStr; 
        const rawResponse = await fetch(apiUrl, {
            method: 'GET',
            headers: {
                'Accept': 'application/json',
                'Content-Type': 'application/json',
            },
        });

        if(rawResponse.ok == true){
            resolve(rawResponse.json());
        }else{
            const result = await rawResponse.json();
             
            resolve(result);
        }
    });
};