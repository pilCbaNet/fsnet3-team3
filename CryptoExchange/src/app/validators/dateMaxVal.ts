import { FormGroup } from "@angular/forms";

export function dateValidator(birthdate:any) {
    return (formGroup: FormGroup) => {
        const bdate = formGroup.controls[birthdate];
        //console.log(bdate.value)

        if(bdate.errors && !bdate.errors['dateValidate']){
            return;
        }
        if(bdate.value > new Date().toISOString().split('T')[0]){
            bdate.setErrors({validate: true})
        } else {
            bdate.setErrors(null);
        }
    }
}