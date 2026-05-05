<script lang="ts">
    type Props ={
        azubi:Azubi
    }
    let {
        azubi
    }:Props=$props();
    let visible = $state(false);
</script>
<div id="AzubiBlock">
    <div>
        <span class="AzubiName">
            {azubi.name}
            <label class="Azubibox">
                <input type="checkbox" bind:checked={visible} />
            </label>
            </span>
            <span class="Input">
                <span>
                    Lehrjahr:
                </span>
                <span>
                    {azubi.lehrjahr}
                </span>
            </span>
            <span class="Input">
                <span>
                    Standort:
                </span>
                <span>
                    {azubi.standort}
                </span>
            </span>
            <span class="Input">
                <span>
                    Richtung:
                </span>
                <span>
                    {azubi.richtung}
                </span>
            </span>
            <span class="Input">
                <span>
                    Zeitraum:
                </span>
                <span>
                    {azubi.zeitraum}
                </span>
            </span>
            <span class="AzubiText">
                {#if visible}
                <p>{azubi.text}</p>
                {/if}
            </span>
        </div>
    </div>