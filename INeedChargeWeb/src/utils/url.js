export function getApiUrl (apicode) {

    const host = window.location.origin;

    const env = {
        "http://localhost:3000":"http://localhost:5198", 
        "http://127.0.0.1:3000":"http://127.0.0.1:5198",
    }

    const urlMap = new Map([
        //signalR用url
 
        //API
        ["Operator", env[host]+ "/data/GetOneOperator"],
        ["SelectStation", env[host]+ "/data/GetSelectStationList"],
        ["GetOneStation", env[host]+ "/data/GetOneStation"],
        ["GetStationPositionList", env[host]+ "/data/GetStationPositionList"],
 

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

export async function fetchPost(apiUrl,data){
    return new Promise(async (resolve,reject) => {
        const rawResponse = await fetch(apiUrl, {
            method: 'POST',
            headers: {
                'Accept': 'application/json',
                'Content-Type': 'application/json',
                'X-Goog-Api-Key': import.meta.env.VITE_GOOGLE_MAPS_API_KEY
            },
            body: JSON.stringify(data)
        });
        resolve(rawResponse.json()); // 正確完成的回傳方法
    });
}