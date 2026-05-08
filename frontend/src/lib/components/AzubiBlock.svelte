<script lang="ts">
    import type { AzubiRequestDTO } from "$lib/api/Api";
    type Props ={
        request: AzubiRequestDTO,
        userid: string | undefined
    }
    let { request, userid }:Props=$props();
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
            <a href="/AzubiPage/sendAnswer?toRequest={request.requestId}" type="button">Anfragen</a>
            {#if request.author?.id === userid}
            <a href=""></a>
            {/if}
        </div>
    </div>