<script lang="ts">
	import RegisterAbb from "$lib/components/RegisterAbb.svelte";

</script>

<div class="post-form-container">
    <form method="POST">
        <div class="form-group">
            <label for="username">Username:</label>
            <input type="text" id="username" name="username">
        </div>
        <div class="form-group">
            <label for="password">Password:</label>
            <input type="text" id="password" name="password">
        </div>
        <div class="form-group">
            <input id="submit" type="submit">
        </div>
    </form>
</div>