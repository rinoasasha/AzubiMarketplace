<script>
	// stateVariable = the state which should be updated when checkboxes are selected
	// both received as component property
	let { title, statePropToBind = $bindable() } = $props();
</script>

<div class="container">
	<label id="FilterTextLabel">
        <span style="font-weight:bold;">{title}:</span>
		<input type="text" bind:value={statePropToBind}>
</label>
</div>
