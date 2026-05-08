<script lang="ts">
    import type { AzubiRequestCreateDTO } from "$lib/api/Api";

//     let name = '';
//     let lehrjahr = 1;
//     let standort = '';
//     let richtung = '';
//     let zeitraum = '';
//     let text = '';
//     let postLoading = false;
//     let postError = null;
//     let postSuccess = false;

// const API_BASE = (import.meta.env.PUBLIC_API_BASE_URL ?? 'http://localhost:5000').replace(/\/$/, '');

// async function postRequest() {
//     postLoading = true;
//     postError = null;
//     postSuccess = false;

//     if (!name || !lehrjahr || !standort || !richtung || !zeitraum || !text) {
//         postError = 'All fields are required.';
//         postLoading = false;
//         return;
//     }
//     if (isNaN(lehrjahr) || lehrjahr < 1) {
//         postError = 'Lehrjahr must be a positive number.';
//         postLoading = false;
//         return;
//     }

//     const requestData = {
//         name: name,
//         lehrjahr: Number(lehrjahr),
//         standort: standort,
//         richtung: richtung,
//         zeitraum: zeitraum,
//         text: text
//     };

//     try {
//         const response = await fetch(`${API_BASE}/Request`, {
//             method: 'POST',
//             headers: {
//             'Content-Type': 'application/json'
//         },
//         body: JSON.stringify(requestData)
//     });

//     if (!response.ok) {
//         const errorData = await response.json(); // Try to parse error message from backend
//         throw new Error(`HTTP error! status: ${response.status}, message: ${errorData.message || 'Unknown error'}`);
//     }

//       const responseData = await response.json(); // Usually, a successful POST also returns data
//     console.log('Request posted successfully:', responseData);

//     postSuccess = true; //clears form after successful post
//         name = '';
//         lehrjahr = 1;
//         standort = '';
//         richtung = '';
//         zeitraum = '';
//         text = '';

//     } catch (err) {
//         console.error("Error posting request:", err);
//         postError = `Failed to post request: ${err.message || 'Please try again later.'}`;
//     } finally {
//         postLoading = false;
//     }
// }
</script>

<!-- <div class="post-form-container">
    <h1>Post a New Request</h1>

    <form method="POST">
    <div class="form-group">
        <label for="name">Name:</label>
        <input type="text" id="name" bind:value={name} required />
    </div>

    <div class="form-group">
        <label for="lehrjahr">Lehrjahr:</label>
        <input type="number" id="lehrjahr" bind:value={lehrjahr} min="1" required />
    </div>

    <div class="form-group">
        <label for="standort">Standort:</label>
        <input type="text" id="standort" bind:value={standort} required />
    </div>

    <div class="form-group">
        <label for="richtung">Richtung:</label>
        <input type="text" id="richtung" bind:value={richtung} required />
    </div>

    <div class="form-group">
        <label for="zeitraum">Zeitraum:</label>
        <input type="text" id="zeitraum" bind:value={zeitraum} required />
    </div>

    <div class="form-group">
        <label for="text">Text:</label>
        <textarea id="text" bind:value={text} required></textarea>
    </div>

    <button type="submit" disabled={postLoading}>
        {#if postLoading}
        Posting...
        {:else}
        Submit Request
        {/if}
    </button>

    {#if postError}
        <p class="error-message">Error: {postError}</p>
    {/if}

    {#if postSuccess}
        <p class="success-message">Request posted successfully!</p>
    {/if}
</form>
</div> -->