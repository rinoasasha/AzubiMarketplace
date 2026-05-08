import { apiBaseUrl, fallbackReturnUrl } from "$lib/config";
import { ApiProvider } from "$lib/api/ApiProvider";
import { redirect, type ServerLoadEvent } from "@sveltejs/kit";
import type { LayoutServerLoad } from "./$types";
import { Api, type UserDTO } from "$lib/api/Api";

export const load: LayoutServerLoad = async (context) => {
    const api_provider = new ApiProvider(context.cookies)

    let user;
    try {
        let user = await api_provider.api.api.v1AuthMeList().then((res) => {
            return res.data
        })
        console.log({user});
        return {
            login: false,
            currentUser: user,
            currentUserId: user.id
        };
    } catch (e) {
        console.log("user auth request failed --> login", e);
        const loginUrl = new URL(`${apiBaseUrl}/api/v1/auth/signin/bosch`);
        console.log(loginUrl.toString())

        let currentUri = context.url ?? new URL(fallbackReturnUrl);

        if (currentUri.hostname === "undefined") {
            currentUri = new URL(fallbackReturnUrl);
        }

        if (currentUri.hostname === "localhost") {
            currentUri.protocol = "http";
        }

        loginUrl.searchParams.set("ReturnUrl", currentUri.toString());
        console.log("Redirecting to", loginUrl.toString());
        redirect(302, loginUrl);
        return {
            login: true,
            user: null as unknown as UserDTO,
            currentUserId: null as unknown as string,
        }
    }
};