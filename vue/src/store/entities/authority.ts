import Entity from './entity'
class Meta {
    title:string;
 
}
export default class Authority extends Entity<number>{
    moudleName:string;
    parient:string;
    name:string;
    path:string;
    menuIcon:string;
    meta:Meta;
    componentName:string;
    component:string;
    permission:string;
    children:Array<Authority>;
   
}