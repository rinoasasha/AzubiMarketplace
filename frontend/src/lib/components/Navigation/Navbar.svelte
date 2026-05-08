<script lang="ts">
    import { apiBaseUrl, fallbackReturnUrl } from "$lib/config";
    import { page } from "$app/state";
    import type { LayoutData } from "../../../routes/$types";

    interface Props {
        data: LayoutData
    }

    let { data }: Props = $props();
    const returnUrl = page.url.searchParams.get("returnUrl") ?? page.url;

    function getLoginUrl(): string {
        const loginUrl = new URL(`${apiBaseUrl}/api/v1/Auth/signin/bosch`);

        let currentUri = new URL(page.url);
        currentUri.pathname = "/";
        currentUri.search = "";

        try {
            currentUri = new URL(returnUrl);
        } catch (e) {
            console.error("Failed to parse returnUrl on login");
        }

        if (currentUri.hostname === "undefined") {
            currentUri = new URL(fallbackReturnUrl);
        }

        if (currentUri.hostname === "localhost") {
            currentUri.protocol = "http";
        }

        loginUrl.searchParams.set("ReturnUrl", currentUri.toString());

        console.log({loginUrl})
        return loginUrl.toString();
    }

    function getLogoutUrl(): string {
        const loginUrl = new URL(`${apiBaseUrl}/api/v1/Auth/signout`);

        let currentUri = new URL(page.url);
        currentUri.pathname = "/";
        currentUri.search = "";

        try {
            currentUri = new URL(returnUrl);
        } catch (e) {
            console.error("Failed to parse returnUrl on login");
        }

        if (currentUri.hostname === "undefined") {
            currentUri = new URL(fallbackReturnUrl);
        }

        if (currentUri.hostname === "localhost") {
            currentUri.protocol = "http";
        }

        loginUrl.searchParams.set("ReturnUrl", currentUri.toString());

        console.log({loginUrl})
        return loginUrl.toString();
    }

</script>
<div id="nav">
    {#if data.login}
	<a href={getLoginUrl()}> Login (Bosch SSO)</a>
    {:else}
    <a href={getLogoutUrl()}> Logout<br>{data.user?.localUsername}</a>
    {/if}
</div>