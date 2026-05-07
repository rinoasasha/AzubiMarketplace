<script lang="ts">
    import {
        Button,
        ComboBox,
        Dropdown,
        Modal,
        MultiSelect,
        Portal,
        Stack,
    } from "carbon-components-svelte"; /*does not work yet*/

    let open = false;

    const contactItems = [
        { id: "0", text: "Slack" },
        { id: "1", text: "Email" },
        { id: "2", text: "Fax" },
        { id: "3", text: "Teams" },
        { id: "4", text: "Phone" },
    ];
</script>

<nav id="nav">
	<a href="/">home</a>
	<a href="/AzubiPage">azubis</a>
</nav>


<Button on:click={() => (open = true)}>Open modal</Button>

<Portal>
    <Modal
        bind:open
        size="sm"
        modalHeading="Add a contact"
        primaryButtonText="Add"
        secondaryButtonText="Cancel"
        on:click:button--secondary={() => (open = false)}
    >
        <Stack gap={4}>
            <ComboBox
                light
                labelText="Contact method"
                placeholder="Select contact method"
                items={contactItems}
            />
        <Dropdown
            labelText="Preferred channel"
            selectedId="0"
            items={contactItems}
        />
            <MultiSelect
                labelText="Notification methods"
                label="Select methods..."
                items={contactItems}
            />
        </Stack>
    </Modal>
</Portal>
