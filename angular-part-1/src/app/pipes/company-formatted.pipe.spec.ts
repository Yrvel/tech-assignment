import { Company } from '../models/company.model';
import { CompanyFormattedPipe } from './company-formatted.pipe';

describe('CompanyFormattedPipe', () => {
  it('create an instance of company', () => {
    const pipe = new CompanyFormattedPipe();
    expect(pipe).toBeTruthy();
  });

  it('Format an company', () => {
    const pipe = new CompanyFormattedPipe();
    const expectedCompanyFormatted = 'Romaguera-Crona: Multi-layered client-server neural-net, Balance Sheet: harness real-time e-markets';

    const actualCompany = new Company('Romaguera-Crona', 'Multi-layered client-server neural-net', 'harness real-time e-markets')
    expect(pipe.transform(actualCompany)).toBe(expectedCompanyFormatted);
  });
});
