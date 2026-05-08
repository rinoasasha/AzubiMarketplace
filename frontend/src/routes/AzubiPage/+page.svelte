<script lang="ts">
	import type { PageProps } from './$types';
    import type { AzubiRequestDTO } from "$lib/api/Api";
    import RequestFetcher from "$lib/components/RequestFetcher.svelte";
    import AzubiBlock from "$lib/components/AzubiBlock.svelte";

    let { data }: PageProps = $props();
</script>

<a id="Anzeige" href="/AnzeigePage">Anzeige erstellen</a>

<div id="Banner">
    <span class="BannerElement">Zeitraum</span>
    <span class="BannerElement">Lehrjahr</span>
    <span class="BannerElement">Skills</span>
    <span class="BannerElement">Standort</span>
    <span class="BannerElement">Richtung</span>
</div>

<nav id="nav">
	<a href="/">home</a>
    <a href="/UserPage">user</a>
</nav>

{#each data.requests as request}
    <AzubiBlock {request}/>
{/each}