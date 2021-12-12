import { Component, OnInit } from '@angular/core';
import { SharedService } from 'src/app/shared.service';

@Component({
  selector: 'app-show-dep',
  templateUrl: './show-dep.component.html',
  styleUrls: ['./show-dep.component.css']
})
export class ShowDepComponent implements OnInit {
  constructor(private service:SharedService) { }

  DepartmentList: any = [];
  ModalTitle:string;
  ActivateAddEditDepComp:boolean = false;
  dep:any;

  DepartmentIdFlter:string = "";
  DepartmentNameFlter:string = "";
  DepartmentListWithoutFilter:any = [];

  ngOnInit(): void {   
    this.refreshDepList();
  }

  refreshDepList(){
    this.service.getDepList().subscribe(data =>{
      this.DepartmentList = data;
      this.DepartmentListWithoutFilter = data;
    })
  }

  addClick(){
    this.dep ={
      DepartmentId:0,
      DepartmentName:""
    }

    this.ModalTitle = "Add Department";
    this.ActivateAddEditDepComp = true;
  }

  closeClick(){
    this.ActivateAddEditDepComp = false;
    this. refreshDepList();
  }

  editClick(item){
    this.dep = item;
    this.ModalTitle = "Edit Department";
    this.ActivateAddEditDepComp = true;
  }

  deleteClick(item){
    if(confirm('Are you sure??')){
      this.service.deleteDepartent(item.DepartmentId).subscribe(data=>{
        alert(data.toString());
        this.refreshDepList();
      })
    }
  }

  FilterFn(){
    var DepartmentIdFlter = this.DepartmentIdFlter;
    var DepartmentNameFlter = this.DepartmentNameFlter;

    this.DepartmentList = this.DepartmentListWithoutFilter.filter(function(el){
      return el.DepartmentId.toString().toLowerCase().includes(
        DepartmentIdFlter.toString().trim().toLowerCase()
      )&&
      el.DepartmentName.toString().toLowerCase().includes(
        DepartmentNameFlter.toString().trim().toLowerCase()
      )
    })
  }

  sortResult(prop, asc){
    //console.log(prop);
      this.DepartmentList = this.DepartmentListWithoutFilter.sort(function(a, b){
        if(asc){
           return (a[prop]>b[prop])?1:((a[prop]<b[prop])?-1:0);
        }else{
          return (b[prop]>a[prop])?1:((b[prop]<a[prop])?-1:0);
        }
      })

      //console.log(this.DepartmentList);
  }

}
