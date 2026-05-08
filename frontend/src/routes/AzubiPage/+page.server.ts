import type { AzubiRequestDTO } from "$lib/api/Api";
import type { PageServerLoad } from "./$types";
import { ApiProvider } from "$lib/api/ApiProvider";

export const load: PageServerLoad = async (context) => {
    const api_provider = new ApiProvider(context.cookies).api
    let all_requests

    try {
        all_requests = await api_provider.api.v1RequestAllList()
        console.log(all_requests)
    } catch (e) {
        console.log("schade", e)
        return {requests: [] as AzubiRequestDTO[]}
    }

    return {requests: all_requests.data}
}