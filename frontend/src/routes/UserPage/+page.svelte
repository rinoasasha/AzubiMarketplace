<script lang="ts">
	import RegisterAzubi from "$lib/components/RegisterAzubi.svelte";
    import type { PageProps } from './$types';
    import type { LayoutProps } from "../$types";

	let { data, form }: PageProps = $props();
</script>

<div class="post-form-container" style="margin-top: 10rem;">
    <div>Your current role(s):</div>
    <div>
        {#each data.roles as role}
        <span>{role}</span>
        {#if !(data.roles[data.roles.length -1] === role)}
            <span style="padding-right: .4rem;">;</span>
        {/if}
        {/each}
    </div>
    <div style="display: flex;">
        {#if !data.roles.includes("Azubi")}
        <div id="teamPicker">
            <a href="/UserPage/Azubi">Change to Azubi</a>
        </div>
        {/if}
        {#if !data.roles.includes("ABB")}
        <div id="teamPicker">
            <a href="/UserPage/Abb">Change to Abb</a>
        </div>
        {/if}
        {#if !data.roles.includes("Admin")}
        <div id="teamPicker">
            <a href="/UserPage/no">Give me Admin Rights!</a>
        </div>
        {/if}
    </div>
    <div style="margin-top: 3rem;">Change Profile:</div>
    <form method="POST" style="margin-top: .5rem;">
        <div class="form-group">
            <label for="LocalUsername">Username:</label>
            <input type="text" id="LocalUsername"/>
        </div>
        <div class="form-group">
            <label for="FirstName">First Name:</label>
            <input type="text" id="FirstName"/>
        </div>
        <div class="form-group">
            <label for="LastName">Last Name:</label>
            <input type="text" id="LastName"/>
        </div>
        <div class="form-group">
            <label for="Department">Department:</label>
            <input type="text" id="Department"/>
        </div>
        <div class="form-group">
            <label for="Location">Location:</label>
            <input type="text" id="Location"/>
        </div>
        {#if data.roles.includes("Azubi")}
        <div class="form-group">
            <label for="TrainingOccupation">Training Occupation:</label>
            <input type="text" id="TrainingOccupation"/>
        </div>
        <div class="form-group">
            <label for="TrainingStartYear">Training Start Year:</label>
            <input type="text" id="TrainingStartYear"/>
        </div>
        {/if}
        <input id="teamPicker" type="submit" value="Change Profile">
    </form>
</div>