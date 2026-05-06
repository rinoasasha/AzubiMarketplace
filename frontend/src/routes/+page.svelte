<script lang="ts">
    import ThemeSwitch from '$lib/components/ThemeSwitch.svelte'
    import AzubiBlock from '$lib/components/AzubiBlock.svelte';
    import Login from '$lib/components/Login.svelte';
    let azubis:Azubi[] = [
        {
            name:"Azubi1", lehrjahr:1, standort:"Feuerbach", richtung:"FISI", zeitraum:"März-Sep.", text:"lorem"
        },
        {
            name:"Azubi2", lehrjahr:1, standort:"Feuerbach", richtung:"FIAE", zeitraum:"März-Sep.", text:"lorem"
        },
        {
            name:"Azubi3", lehrjahr:2, standort:"Feuerbach", richtung:"FISI", zeitraum:"März-Sep.", text:"lorem"
        },
        {
            name:"Azubi4", lehrjahr:1, standort:"Feuerbach", richtung:"FIAE", zeitraum:"März-Sep.", text:"lorem"
        },
        {
            name:"Azubi5", lehrjahr:3, standort:"Feuerbach", richtung:"FISI", zeitraum:"März-Sep.", text:"lorem"
        },
        {
            name:"Joshi1", lehrjahr:2, standort:"Feuerbach", richtung:"FISI", zeitraum:"März-Sep.", text:"Lorem ipsum dolor sit amet, consectetur adipiscing elit. Cras rhoncus, lacus a faucibus semper, dolor metus rutrum turpis, a aliquam arcu ipsum vel dui. Donec imperdiet dignissim erat ut porttitor. Praesent eu turpis ultrices, posuere turpis non, gravida nisl. Mauris viverra semper nulla. Duis euismod semper turpis eget interdum. Nullam facilisis diam a turpis maximus cursus. Nulla at libero non massa consequat auctor in sed augue. Fusce feugiat ac ipsum ac commodo. In rhoncus dui vitae condimentum rutrum. Quisque urna erat, lobortis nec dignissim at, posuere at lectus. Fusce ullamcorper, orci dapibus hendrerit sagittis, turpis urna convallis mi, vel viverra magna ex eget nulla. Pellentesque habitant morbi tristique senectus et netus et malesuada fames ac turpis egestas. Donec sit amet varius urna, nec consectetur justo. Pellentesque id odio id tellus commodo consequat et sed justo. Pellentesque finibus dolor eget quam imperdiet ultrices non nec lacus. Pellentesque pellentesque vulputate dignissim. Lorem ipsum dolor sit amet, consectetur adipiscing elit. Ut sapien enim, porttitor in justo interdum, pulvinar dignissim ante. Sed nec purus porta, laoreet est ac, sagittis risus. Suspendisse potenti. Morbi suscipit suscipit lorem, sit amet dignissim lorem. Nunc sit amet enim lobortis sem blandit suscipit hendrerit ut quam. Donec metus sapien, aliquam ac mi non, varius feugiat felis."
        }
        ];



</script>
<div id="TopBar">
    <div id="Logo">
        <button>Azubi</button>
        <button id="In">In</button>
    </div>
    <button id="Anzeige">Anzeige erstellen</button>
    <div id="TopButtons" class="flex justify-center content-center items-center gap-x-2">
        <ThemeSwitch/>
        <Login/>
    </div>
</div>

<div id="Banner">
    <span class="BannerElement">Zeitraum</span>
    <span class="BannerElement">Lehrjahr</span>
    <span class="BannerElement">Skills</span>
    <span class="BannerElement">Standort</span>
    <span class="BannerElement">Richtung</span>
</div>

{#each azubis as azubi}
    <AzubiBlock {azubi}/>
{/each}