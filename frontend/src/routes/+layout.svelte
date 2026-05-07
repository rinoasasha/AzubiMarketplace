<script lang="ts">
	import ThemeSwitch from '$lib/components/ThemeSwitch.svelte'
    import Login from '$lib/components/Login.svelte';
	import './layout.css';
	import favicon from '$lib/assets/favicon.svg';
    import type { LayoutProps } from './$types';

	let { children, data } = $props();
</script>

<svelte:head><link rel="icon" href={favicon} /></svelte:head>
{@render children()}
<div id="TopBar">
    <div id="Logo">
        <button>Azubi</button>
        <button id="In">In</button>
    </div>
    <div id="TopButtons" class="flex justify-center content-center items-center gap-x-2">
        <ThemeSwitch/>
        <!-- <Login/> -->
    </div>
    <div>{data.login.valueOf()}</div>
</div>