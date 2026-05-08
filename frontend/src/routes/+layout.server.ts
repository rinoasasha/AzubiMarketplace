import { apiBaseUrl, fallbackReturnUrl } from "$lib/config";
import { ApiProvider } from "$lib/api/ApiProvider";
import { redirect, type ServerLoadEvent } from "@sveltejs/kit";
import type { LayoutServerLoad } from "./$types";
import { Api, type UserDTO } from "$lib/api/Api";

export const load: LayoutServerLoad = async (context) => {
    if (context.cookies.getAll().length === 0 && context.request.headers.get("Authorization") === null) {
        console.log("user has no cookies --> login");

        return {
            login: true,
            user: null as unknown as UserDTO,
            currentUserId: null as unknown as string,
        };
    }

    const api_provider = new ApiProvider(context.cookies)

    let user;
    try {
        user = await api_provider.api.api.v1AuthMeList()
        console.log({user});
    } catch (e) {
        console.log("user auth request failed --> login", e);

        return {
            login: true,
            user: null as unknown as UserDTO,
            currentUserId: null as unknown as string,
        };
    }

    if (!user || user === null) {
        console.log("user is not authorized, redirecting to oauth login");
        throw getOAuthRedirect(context);
    }

    return {
        login: false,
        currentUser: user.data,
        currentUserId: user.data.id
    };
};

function getOAuthRedirect(context: ServerLoadEvent) {
    const loginUrl = new URL(`${apiBaseUrl}/api/v1/Auth/signin/bosch`);
    let currentUri =  new URL(fallbackReturnUrl);

    if (currentUri.hostname === "undefined") {
        currentUri = context.url ?? new URL(fallbackReturnUrl);
    }

    if (currentUri.hostname === "localhost") {
        currentUri.protocol = "http";
    }

    loginUrl.searchParams.set("ReturnUrl", currentUri.toString());
    console.log("Redirecting to", loginUrl.toString());
    return redirect(302, loginUrl.toString());
}