<script lang="ts">
	import ThemeSwitch from '$lib/components/ThemeSwitch.svelte'
    import Login from '$lib/components/Login.svelte';
	import './layout.css';
	import favicon from '$lib/assets/favicon.svg';
    import type { LayoutProps } from './$types';
	import Navbar from '$lib/components/Navigation/Navbar.svelte';

	let { children, data } = $props();
</script>

<svelte:head><link rel="icon" href={favicon} /></svelte:head>
<Navbar {data}/>
{@render children()}
<div id="TopBar">
    <div id="Logo">
        <button>Azubi</button>
        <button id="In">In</button>
    </div>
    <div id="TopButtons" class="flex justify-center content-center items-center gap-x-2">
        <a href="/">home</a>
        <a href="/AzubiPage">azubis</a>
        <a href="/UserPage">user</a>
        <ThemeSwitch/>
    </div>
</div>