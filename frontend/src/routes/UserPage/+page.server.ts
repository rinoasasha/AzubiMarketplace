import type { PageServerLoad } from "./$types";
import { ApiProvider } from "$lib/api/ApiProvider";
import type { UserEditDTO } from "$lib/api/Api";
import type { Actions } from "@sveltejs/kit";

export const load: PageServerLoad = async (context) => {
    const api_provider = new ApiProvider(context.cookies)

    let roles = await api_provider.api.api.v1AuthMeRoleList()

    return {
        roles: roles.data
    }
}

export const actions = {
    default: async ({cookies, request, url }) => {
        const api_provider = new ApiProvider(cookies).api
        if (!url.searchParams.has("toRequest")) {
            return {success: false}
        }
        const form_data = await request.formData();
        const request_data = {
            localUsername: form_data.get("LocalUsername"),
            firstName: form_data.get("FirstName"),
            lastName: form_data.get("LastName"),
            department: form_data.get("Department"),
            location: form_data.get("Location"),
            trainingOccupation: form_data.get("TrainingOccupation"),
            trainingStartYear: form_data.get("TrainingStartYear")
        } as UserEditDTO

        let post_request = await api_provider.api.v1UserEditSelfPartialUpdate(request_data)
        if(post_request.status === 201) {
            return {success: true}
        } else {
            return {success: false}
        }
    }
} satisfies Actions;