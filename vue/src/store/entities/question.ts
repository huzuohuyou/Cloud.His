import Entity from './entity'

export default class Question extends Entity<number>{
    date:string;
    phone:string;
    dept:string;
    user:string;
    ptno:string;   
    kind:number;   
    role:number;   
    type:number;   
    question:string;   
    reason:string;   
    answer:string;   
    uploadList:string[]
}