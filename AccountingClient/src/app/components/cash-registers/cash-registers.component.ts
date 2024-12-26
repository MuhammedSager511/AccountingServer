import { Component, ElementRef, ViewChild } from '@angular/core';
import { SharedModule } from '../../modules/shared.module';
import { CashRegisterPipe } from '../../pipes/cash-register.pipe';
import { RouterLink } from '@angular/router';
import { CashRegisterModel } from '../../models/cash-register.model';
import { CurrencyTypes } from '../../models/currency-type.model';
import { HttpService } from '../../services/http.service';
import { SwalService } from '../../services/swal.service';
import { NgForm } from '@angular/forms';




@Component({
  selector: 'app-cash-registers',
  standalone: true,
  imports: [SharedModule, CashRegisterPipe, RouterLink],
  templateUrl: './cash-registers.component.html',
  styleUrl: './cash-registers.component.css'
})
export class CashRegistersComponent {
  cashRegisters: CashRegisterModel[] = [];
  search:string = "";
  p: number = 1;
  currencyTypes = CurrencyTypes;

  @ViewChild("createModalCloseBtn") createModalCloseBtn: ElementRef<HTMLButtonElement> | undefined;
  @ViewChild("updateModalCloseBtn") updateModalCloseBtn: ElementRef<HTMLButtonElement> | undefined;

  createModel:CashRegisterModel = new CashRegisterModel();
  updateModel:CashRegisterModel = new CashRegisterModel();

  constructor(
    private http: HttpService,
    private swal: SwalService
  ){}

  ngOnInit(): void {
    this.getAll();
  }

  getAll(){
    this.http.post<CashRegisterModel[]>("CashRegisters/GetAll",{},(res)=> {
      this.cashRegisters = res;
    });
  }

  create(form: NgForm){    
    if(form.valid){
      this.http.post<string>("CashRegisters/Create",this.createModel,(res)=> {
        this.swal.callToast(res);
        this.createModel = new CashRegisterModel();
        this.createModalCloseBtn?.nativeElement.click();
        this.getAll();
      });
    }
  }

  deleteById(model: CashRegisterModel){
    this.swal.callSwal("Delete Case?",`Do you want to delete case ${model.name}?`,()=> {
      this.http.post<string>("CashRegisters/DeleteById",{id: model.id},(res)=> {
        this.getAll();
        this.swal.callToast(res,"info");
      });
    })
  }

  get(model: CashRegisterModel){
    this.updateModel = {...model};
    this.updateModel.currencyTypeValue = this.updateModel.currencyType.value;
  }

  update(form: NgForm){
    if(form.valid){
      this.http.post<string>("CashRegisters/Update",this.updateModel,(res)=> {
        this.swal.callToast(res,"info");
        this.updateModalCloseBtn?.nativeElement.click();
        this.getAll();
      });
    }
  }

  changeCurrencyNameToSymbol(name: string){
    if(name === "TL") return "₺";
    else if(name === "USD") return "$";
    else if(name === "EUR") return "€";
    else return "";
  }
}
