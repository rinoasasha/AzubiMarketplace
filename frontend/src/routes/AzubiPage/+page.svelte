<script lang="ts">
	import type { PageProps } from './$types';
    import type { AzubiRequestDTO } from "$lib/api/Api";
    import RequestFetcher from "$lib/components/RequestFetcher.svelte";
    import AzubiBlock from "$lib/components/AzubiBlock.svelte";
    import FilterInput from './FilterInput.svelte';

    let { data }: PageProps = $props();
    let searchTextState = $state({value: ""});

const includesCaseInsensitive = (str, searchString) =>
	new RegExp(searchString, 'i').test(str);

	let filteredResults = $derived.by(()=>{
		let filteredResults = [];

		console.log('applySearchFilters() triggered, $state changed ...');

		filteredResults = data.requests;

        if(searchTextState.value !== ""){
			filteredResults = filteredResults.filter((data) =>
				includesCaseInsensitive(data, searchTextState.value)
			);
		}

		return filteredResults;
	});

</script>

<a id="Anzeige" href="/AnzeigePage">Anzeige erstellen</a>

<div id="Banner">
    <FilterInput title="Search" bind:statePropToBind={searchTextState.value} />
</div>

<main>
    <RequestFetcher />
</main>

{#each filteredResults as request}
    <AzubiBlock {...{request: request, userid: data.currentUser?.id}}/>
{/each}