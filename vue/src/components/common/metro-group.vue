<template>
    <div>
        <div v-for="item in mainMenu" :key='item.name' id="section1" class="metro-section tile-span-4">
            <h2>{{item.title}}</h2>
            <metroMenu :menuList="item.children">
            </metroMenu>
        </div>
    </div>
</template>
<style scoped src="@/statics/css/bootstrap.css"></style>
<style scoped src="@/statics/css/bootstrap-responsive.css"></style>
<style scoped src="@/statics/css/bootmetro.css"></style>
<style scoped src="@/statics/css/bootmetro-tiles.css"></style>
<style scoped src="@/statics/css/bootmetro-charms.css"></style>
<style scoped src="@/statics/css/metro-ui-light.css"></style>
<style scoped src="@/statics/css/icomoon.css"></style>
<style>
  .fades-enter-active,
  .fades-leave-active {
    transition: opacity 1s
  }

  .fades-enter,
  .fades-leave-to {
    opacity: 0
  }

  .fades-leave,
  .fades-enter-to {
    opacity: 1
  }

  .ivu-modal-body {
    padding: 5px !important;
    font-size: 12px;
    line-height: 1.5;
  }

  .ivu-menu-horizontal {
    height: 40px !important;
    line-height: 40px !important;
  }
  .metro-sections{
    height: auto;
    position: relative;
    overflow: hidden;
    width: 100% !important;;
}
</style>
<script lang="ts">

    import util from '../../lib/util';
    import metroMenu from "@/components/common/metro-menu.vue";
    import { Component, Vue, Inject, Prop, Emit } from 'vue-property-decorator';
    @Component({
        components: { metroMenu },
    })
    export default class ShrinkableMenu extends Vue {
        name: string = 'shrinkableMenu';
        @Prop() groupName: String;
        @Prop({ required: true, type: Array }) mainMenu: Array<any>;
        @Prop({ type: Array }) openNames: Array<string>;
        @Prop({ type: Function }) beforePush: Function;
        @Prop({
            validator: (val) => { return util.oneOf(val, ['dark', 'light']); }
        }) theme: string;
        get bgColor() {
            return this.theme === 'dark' ? '#001529' : '#fff';
        }
        get shrinkIconColor() {
            return this.theme === 'dark' ? '#fff' : '#495060';
        }
        @Emit('on-change')
        handleChange(name: string) {
            let willpush = true;
            if (this.beforePush !== undefined) {
                if (!this.beforePush(name)) {
                    willpush = false;
                }
            }
            if (willpush) {
                this.$router.push({ name: name })
            }
        }
    }
</script>