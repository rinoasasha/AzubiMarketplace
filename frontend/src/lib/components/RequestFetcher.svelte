<script>
    import { onMount } from 'svelte';

    let requests = [];
    let loading = true;
    let error = null;

const API_BASE = (import.meta.env.PUBLIC_API_BASE_URL ?? 'http://localhost:5000').replace(/\/$/, '');

async function fetchRequests() {
    loading = true;
    error = null;

    try {
        const response = await fetch(`${API_BASE}/Request`);

        if (!response.ok) {
        throw new Error(`HTTP error! status: ${response.status}`);
        }

        const data = await response.json();

        const itemsToAppend = Array.isArray(data) ? data : data.data;

        if (itemsToAppend && Array.isArray(itemsToAppend)) {
        // Filter and map to ensure we only get authorId and textContent
            const newRequests = itemsToAppend.map(item => ({
            authorId: item.authorId,
            textContent: item.textContent
        }));

        // Append the new requests to the existing array
        requests = [...requests, ...newRequests];
        } else {
        throw new Error('API response does not contain an array of requests.');
        }
    } catch (err) {
        console.error("Error fetching requests:", err);
        error = "Failed to fetch requests. Please try again later.";
    } finally {
        loading = false;
    }
    }

  // Fetch requests when the component mounts
    onMount(() => {
    fetchRequests();
    });
</script>

<div>
    {#if loading}
        <p>Loading requests...</p>
    {:else if error}
        <p style="color: red;">Error: {error}</p>
        <button onclick={fetchRequests}>Retry</button>
    {:else if requests.length === 0}
        <p>No requests found.</p>
    {:else}
        <ul>
            {#each requests as request (request.authorId + request.textContent)} <!-- Using a unique key for each item -->
            <li>
                <strong>Author ID:</strong> {request.authorId}<br>
                <strong>Content:</strong> {request.textContent}
            </li>
            {/each}
        </ul>
    {/if}

    <button onclick={fetchRequests} disabled={loading}>
        {loading ? 'Fetching...' : 'Fetch More Requests'}
    </button>
</div>