<script>
    import { onMount } from 'svelte';

    let email = '';
    let firstName = '';
    let lastName = '';
    let password = '';
    let username = '';
    let departmentAbbr = '';
    let standort = '';
    let postLoading = false;
    let postError = null;
    let postSuccess = false;

const API_BASE = (import.meta.env.PUBLIC_API_BASE_URL ?? 'http://localhost:5000').replace(/\/$/, '');

async function postRequest() {
    postLoading = true;
    postError = null;
    postSuccess = false;

    if (!email || !firstName || !lastName || !password || !username) {
        postError = 'All fields are required.';
        postLoading = false;
        return;
    }

    const requestData = {
        username: username,
        password: password,
        email: email,
        name: firstName,
        surname: lastName,
        standort: standort,
        abteilung: departmentAbbr,

    };

    try {
        const response = await fetch(`${API_BASE}/Register/abb`, {
            method: 'POST',
            headers: {
            'Content-Type': 'application/json'
        },
        body: JSON.stringify(requestData)
    });

    if (!response.ok) {
        const errorData = await response.json();
        throw new Error(`HTTP error! status: ${response.status}, message: ${errorData.message || 'Unknown error'}`);
    }

    const responseData = await response.json();
    console.log('Request posted successfully:', responseData);

    postSuccess = true;
        username = '';
        password = '';
        email = '';
        firstName = '',
        lastName = '';
        standort = '';
        departmentAbbr = '';

    } catch (err) {
        console.error("Error posting request:", err);
        postError = `Failed to post request: ${err.message || 'Please try again later.'}`;
    } finally {
        postLoading = false;
    }
}
</script>

<div class="post-form-container">
    <h1>Post a New Request</h1>

    <form onsubmit={postRequest}>
        <div class="form-group">
            <label for="username">Username:</label>
            <input type="text" id="username" bind:value={username} required />
        </div>

        <div class="form-group">
            <label for="password">Password:</label>
            <input type="text" id="password" bind:value={password} required />
        </div>

        <div class="form-group">
            <label for="email">Email:</label>
            <input type="text" id="email" bind:value={email} required />
        </div>

        <div class="form-group">
        <label for="firstname">Name:</label>
        <input type="text" id="firstname" bind:value={firstName} required />
    </div>

    <div class="form-group">
        <label for="lastname">Surname:</label>
        <input type="text" id="latname" bind:value={lastName} required />
    </div>

    <div class="form-group">
        <label for="standort">Standort:</label>
        <input type="text" id="standort" bind:value={standort} />
    </div>

    <div class="form-group">
        <label for="departmentAbbr">abteilung:</label>
        <input type="text" id="departmentAbbr" bind:value={departmentAbbr} />
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
</div>