import Entity from './entity'
class Meta {
    title:string;
 
}
export default class Authority extends Entity<number>{
    title:string;
    moudleName:string;
    parient:string;
    name:string;
    father:string;
    path:string;
    menuIcon:string;
    meta:Meta;
    componentName:string;
    component:string;
    permission:string;
    children:Array<Authority>;
   
}