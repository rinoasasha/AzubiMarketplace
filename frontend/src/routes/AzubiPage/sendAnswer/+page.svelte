<script lang="ts">
    import type { PageProps } from './$types';

	let { data, form }: PageProps = $props();
</script>

<div class="post-form-container">
    <form method="POST">
        <div class="form-group">
            <label>your message:</label>
            <input type="text" name="textContent">
            <input id="submit" type="submit">
        </div>
    </form>
</div>