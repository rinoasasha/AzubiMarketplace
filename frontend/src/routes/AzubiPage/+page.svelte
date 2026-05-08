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

<main>
    <RequestFetcher />
</main>

{#each data.requests as request}
    <AzubiBlock {...{request: request, userid: data.currentUser?.id}}/>
{/each}