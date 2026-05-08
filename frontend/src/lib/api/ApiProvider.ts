import type { ServerLoadEvent } from "@sveltejs/kit";
import {Api} from "./Api.ts";
import type { Cookies } from "@sveltejs/kit";

export class ApiProvider{

    public api;

    constructor(cookies?: Cookies){
        if(cookies){
            this.api = new Api({
                baseUrl: "http://localhost:5017",
                baseApiParams: {
                    credentials: 'include',
                    headers: {
                        Cookie: cookies
                        .getAll()
                        .map((cookie) => `${cookie.name}=${cookie.value}`)
                        .join('; ')
                    }
                }
            });
        } else {
            this.api = new Api({
                baseUrl: "http://localhost:5017",
                baseApiParams: {
                    credentials: 'include'  
                }
            });
        }
    }
}