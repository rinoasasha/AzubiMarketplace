<script lang="ts">
	// import { form } from "$app/server";
	import RequestPoster from "$lib/components/RequestPoster.svelte";
    import type { PageProps } from './$types';
    
	let { data, form }: PageProps = $props();

</script>

<nav id="nav">
    <a href="/">home</a>
    <a href="/AzubiPage">azubis</a>
    <a href="/UserPage">user</a>
</nav>

<form method="POST">
    <input type="text" name="textContent">
    <input type="submit">
</form>

<main>
    <!-- <RequestPoster /> -->
</main>