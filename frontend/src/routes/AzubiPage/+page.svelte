<script lang="ts">
    import RequestFetcher from "$lib/components/RequestFetcher.svelte";
    import AzubiBlock from "$lib/components/AzubiBlock.svelte";
    let azubis:Azubi[] = [
        {name:"placeholder", lehrjahr:1, standort:"placeholder", richtung:"placeholder", zeitraum:"placeholder", text:"placeholder"},
    ]

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

<main>
    <RequestFetcher />
</main>

{#each azubis as azubi}
    <AzubiBlock {azubi}/>
{/each}