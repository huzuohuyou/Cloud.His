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
            let settingList=this.$store.state.app.menuList.filter(item => item.sub===true && item.componentName===this.$store.state.app.currentContiner);
            // return settingList;

            let settingList2=[]
            for ( var  i = 0; i < this.$store.state.authoritymain.list.length; i++) {
                settingList2= this.$store.state.authoritymain.list[i].children
                .filter(item => item.componentName === this.$store.state.app.currentContiner);
                if (settingList2.length >0) { break; }
            }
            
           
            var tmp=[ {
                path:settingList2[0].path,
                name:settingList2[0].name,
                meta:settingList2[0].meta,
                menuIcon:settingList2[0].menuIcon,
                componentName:settingList2[0].componentName,
                children:settingList2[0].children,
                component: () => import(settingList2[0].component),

            }];
            console.log("===================")
            console.log(tmp)
            console.log(settingList)
            return  tmp;
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