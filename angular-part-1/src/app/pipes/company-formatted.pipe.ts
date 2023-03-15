import { Pipe, PipeTransform } from '@angular/core';
import { Company } from '../models/company.model';

@Pipe({
  name: 'companyFormatted'
})
export class CompanyFormattedPipe implements PipeTransform {

  transform(company: Company): string {
    if (!company) {
      return '';
  }
  
  return company.name + ': ' + company.catchPhrase + ', Balance Sheet: ' + company.bs;
  }

}
