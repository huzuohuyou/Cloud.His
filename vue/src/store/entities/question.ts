import Entity from './entity'

export default class Question extends Entity<number>{
    date:string;
    phone:string;
    dept:string;
    user:string;
    ptno:string;   
    kind:number=1;   
    role:number=1;   
    type:number=1;   
    question:string;   
    reason:string;   
    answer:string;   
    uploadList:string[]
}