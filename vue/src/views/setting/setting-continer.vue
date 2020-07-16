<template>
    <div class="continer">
        <SubFormContiner :menuList="menuList" :defaultView="defaultView"></SubFormContiner>
    </div>
</template>
<script lang="ts">
    import { Component, Vue, Inject, Prop, Watch } from 'vue-property-decorator';
    import util from '@/lib/util';
    import 'viewerjs/dist/viewer.css'
    import SubFormContiner from "@/components/common/subform-continer.vue";
    import AbpBase from '@/lib/abpbase'

    @Component({
        components: {
            SubFormContiner
        }
    })
    export default class Setting extends AbpBase {
        defaultView: string = '/setting/user';

        get menuList() {

            let settingList = []
            for (var i = 0; i < this.$store.state.authoritymain.list.length; i++) {
                for (var j = 0; j < this.$store.state.authoritymain.list[i].children.length; j++)
                    if (this.$store.state.authoritymain.list[i].children[j].componentName === this.$store.state.app.currentContiner) {
                        settingList = this.$store.state.authoritymain.list[i].children[j].children;
                        break;
                    }
            }
            return settingList;
        }


    }

</script>
<style>
    .continer {
        height: 98%;
        padding: 0px;
        background-color: #2d8cf000;
    }
</style>