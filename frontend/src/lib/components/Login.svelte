<script lang='ts'>
	import { onMount } from "svelte";

const headerState = $state({
    currentUserId: null as string | null,
    isLoggedIn: false,
    currentDisplayName: ''
});

const API_BASE = (import.meta.env.PUBLIC_API_BASE_URL ?? 'http://localhost:5000').replace(/\/$/, '');

async function toggleLogin() {
    if (headerState.isLoggedIn) {
        window.location.href = `${API_BASE}/api/v1/auth/signout?returnUrl=${encodeURIComponent(window.location.origin)}`;
        return;
    }

    window.location.href = `${API_BASE}/api/v1/auth/signin/bosch?returnUrl=${encodeURIComponent(window.location.origin)}`;
};

async function loadCurrentUser() {
    const response = await fetch(`${API_BASE}/api/v1/auth/@me`, { credentials: 'include' });
    console.log(response)
    if (response.status === 401 || response.status === 404) {
        headerState.currentUserId = null;
        headerState.currentDisplayName = '';
        headerState.isLoggedIn = false;
        return;
    }
    if (response.ok) {
        const data=await response.json();
        if(!data.localUsername || !data.firstName) {
            return;
        }
        headerState.currentUserId = data.localUsername;
        headerState.isLoggedIn = true;
        headerState.currentDisplayName = data.firstName;
    }
    if (!response.ok) {
        throw new Error('Failed to load current user.');
    }
    const data = await response.json()
    headerState.currentUserId = data.user
    headerState.isLoggedIn = true;
};

onMount(() => {
    loadCurrentUser()
})

export {headerState, toggleLogin};
</script>

<div class="login-box">
    {#if headerState.isLoggedIn && headerState.currentUserId}
        <span class="login-user">
            <a
                href={`/profile/${headerState.currentUserId}`}
                class="login-user__link"
            >{headerState.currentDisplayName || 'User'}</a>
        </span>
    {/if}
    <button type="button" onclick={toggleLogin}>
        {headerState.isLoggedIn ? 'Logout' : 'Login'}
    </button>
</div>