import { redirect, type Actions } from "@sveltejs/kit";
import { page } from "$app/state";
import type { ABBResponseCreateDTO } from "$lib/api/Api";
import { ApiProvider } from "$lib/api/ApiProvider";
import { URLSearchParams } from "url";
import { fallbackReturnUrl } from "$lib/config";

if (!page.url.searchParams.has("toRequest")) {
    redirect(300, fallbackReturnUrl)
}
const request_id = page.url.searchParams.get("toRequest")

export const actions = {
    default: async ({cookies, request}) => {
        const api_provider = new ApiProvider(cookies).api
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