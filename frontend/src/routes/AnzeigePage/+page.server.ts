import type { Actions } from "@sveltejs/kit";
import type { AzubiRequestCreateDTO } from "$lib/api/Api";
import { ApiProvider } from "$lib/api/ApiProvider";

export const actions = {
    default: async ({cookies, request}) => {
        const api_provider = new ApiProvider(cookies).api
        const form_data = await request.formData();
        const form_textContent = form_data.get("textContent");
        const request_data = {
            textContent: form_textContent
        } as AzubiRequestCreateDTO

        let post_request = await api_provider.api.v1RequestCreateCreate(request_data)
        if(post_request.status === 201) {
            return {success: true}
        } else {
            return {success: false}
        }
    }
} satisfies Actions;