import { redirect, type Actions } from "@sveltejs/kit";
import { page } from "$app/state";
import type { ABBResponseCreateDTO } from "$lib/api/Api";
import { ApiProvider } from "$lib/api/ApiProvider";
import { fallbackReturnUrl } from "$lib/config";


export const actions = {
    default: async ({cookies, request, url }) => {
        const api_provider = new ApiProvider(cookies).api
        if (!url.searchParams.has("toRequest")) {
            return {success: false}
        }
        const request_id = url.searchParams.get("toRequest")
        const form_data = await request.formData();
        const form_textContent = form_data.get("textContent");
        const request_data = {
            textContent: form_textContent,
            relatedRequestId: request_id
        } as ABBResponseCreateDTO

        let post_request = await api_provider.api.v1ResponseCreateCreate(request_data)
        if(post_request.status === 201) {
            return {success: true}
        } else {
            return {success: false}
        }
    }
} satisfies Actions;