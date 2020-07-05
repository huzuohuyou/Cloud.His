<template>
    <div>
        <metroMenuItem 
        v-for="item in menuList" 
        :key="item.message" 
        :menuIcon="item.menuIcon" 
        :title="item.meta.title"
        :page="item.componentName" 
        :componentName="item.componentName"
        :compmentUrl="item.compmentUrl">
        </metroMenuItem>

    </div>
</template>

<script lang="ts">

import util from '../../lib/util';
import metroMenuItem from "@/components/common/metro-menu-item.vue";
import { Component, Vue,Inject,Prop,Emit } from 'vue-property-decorator';
@Component({
    components:{metroMenuItem},
})
export default class ShrinkableMenu extends Vue {
    name:string='shrinkableMenu';
    @Prop() shrink:boolean;
    @Prop({required:true,type:Array}) menuList:Array<any>;
    @Prop({type:Array}) openNames:Array<string>;
    @Prop({type:Function}) beforePush:Function;
    @Prop({
           validator:(val)=>{return util.oneOf(val, ['dark', 'light']);}
    }) theme:string;
    get bgColor(){
            return this.theme === 'dark' ? '#001529' : '#fff';
    }
    get shrinkIconColor () {
        return this.theme === 'dark' ? '#fff' : '#495060';
    }
    @Emit('on-change')
    handleChange(name:string){
        let willpush = true;
        if (this.beforePush !== undefined) {
            if (!this.beforePush(name)) {
                willpush = false;
            }
        }
        if (willpush) {
            this.$router.push({name:name})
        }
    }
}
</script>
