<script lang="ts">
    import type { AzubiRequestDTO } from "$lib/api/Api";
	import { redirect } from "@sveltejs/kit";
    type Props ={
        request: AzubiRequestDTO
    }
    let {
        request
    }:Props=$props();
    console.log(request)
    let visible = $state(false);
</script>
<div id="AzubiBlock">
    <div>
        <span class="AzubiName">
            {`${request.author?.firstName} ${request.author?.lastName}`}
            <label class="Azubibox">
                <input type="checkbox" bind:checked={visible} />
            </label>
            </span>
            <span class="Input">
                <span>
                    Lehrjahr:
                </span>
                <span>
                    {request.author?.trainingStartYear}
                </span>
            </span>
            <span class="Input">
                <span>
                    Standort:
                </span>
                <span>
                    {request.author?.location}
                </span>
            </span>
            <span class="Input">
                <span>
                    Ausbildungsberuf:
                </span>
                <span>
                    {request.author?.trainingOccupation}
                </span>
            </span>
            <span class="AzubiText">
                {#if visible}
                <p>{request.textContent}</p>
                {/if}
            </span>
            <a href="/AzubiPage/sendAnswer?toRequest={request.requestId}" type="button"> <!-- Schickt User zum Answer-Form -->
                Anfragen
            </a>
        </div>
    </div>