<script lang="ts">
import { onMount } from 'svelte';
import { MoonIcon, SunIcon } from 'heroicons-svelte/24/outline';

  let theme: 'light' | 'dark' | null = $state(null);

  function applyTheme(newTheme: 'light' | 'dark') {
    theme = newTheme;
    if (typeof window !== 'undefined') {
      document.documentElement.classList.remove('light', 'dark');
      document.documentElement.classList.add(newTheme);
      localStorage.setItem('theme', newTheme);
      document.documentElement.style.colorScheme = newTheme;
    }
  }

  function toggleTheme() {
    const newTheme = theme === 'light' ? 'dark' : 'light';
    applyTheme(newTheme);
  }

  onMount(() => {
    const storedTheme = localStorage.getItem('theme');
    const systemPrefersDark = window.matchMedia('(prefers-color-scheme: dark)').matches;

    if (storedTheme === 'light' || storedTheme === 'dark') {
      applyTheme(storedTheme);
    } else if (systemPrefersDark) {
      applyTheme('dark');
    } else {
      applyTheme('light');
    }

    const mediaQuery = window.matchMedia('(prefers-color-scheme: dark)');
    const handleChange = (e: MediaQueryListEvent) => {
      if (!localStorage.getItem('theme')) {
        applyTheme(e.matches ? 'dark' : 'light');
      }
    };
    mediaQuery.addEventListener('change', handleChange);

    return () => mediaQuery.removeEventListener('change', handleChange);
  });
</script>

{#if theme}
  <button
    onclick={toggleTheme}
    class="p-2 rounded-full transition-colors  text-[var(--global-color-3)] dark:text-[var(--global-color-1)] focus:none"
    aria-label="Theme umschalten"
  >
    {#if theme === 'light'}
      <MoonIcon class="h-5 w-5"/>
    {:else}
      <SunIcon class="h-5 w-5"/>
    {/if}
  </button>
{/if}