import type { PageServerLoad } from "./$types";
import { ApiProvider } from "$lib/api/ApiProvider";

export const load: PageServerLoad = async (context) => {
    const api_provider = new ApiProvider(context.cookies).api

    try {
        await api_provider.api.v1UserAbbPartialUpdate()
    } catch (e) {
        return
    }
}