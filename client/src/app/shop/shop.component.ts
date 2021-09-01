import { Component, ElementRef, OnInit, ViewChild } from '@angular/core'
import { IBrand } from '../shared/models/brand'
import { IProduct } from '../shared/models/product'
import { IType } from '../shared/models/productType'
import { ShopParams } from '../shared/models/shopParams'
import { ShopService } from './shop.service'

@Component({
  selector: 'app-shop',
  templateUrl: './shop.component.html',
  styleUrls: ['./shop.component.scss'],
})
export class ShopComponent implements OnInit {
  @ViewChild('search', { static: true }) searchTerm: ElementRef
  products: IProduct[]
  brands: IBrand[]
  types: IType[]
  shopParams = new ShopParams()
  totalCount: number
  sortOptions = [
    { name: 'Alphabetical', value: 'name' },
    { name: 'Price: Low to high', value: 'priceAsc' },
    { name: 'Price: High to low', value: 'priceDesc' },
  ]

  constructor(private shopService: ShopService) {}

  ngOnInit(): void {
    this.getProducts()
    this.getBrands()
    this.getTypes()
  }

  getProducts() {
    this.shopService.getProducts(this.shopParams).subscribe(
      (res) => {
        this.products = res.data
        this.shopParams.pageNumber = res.pageIndex
        this.shopParams.pageSize = res.pageSize
        this.totalCount = res.count
      },
      (err) => {
        console.log(err)
      },
      () => {
        console.log('Completed...')
      },
    )
  }

  getBrands() {
    this.shopService.getBrands().subscribe(
      (res) => {
        this.brands = [{ id: 0, name: 'All' }, ...res]
      },
      (err) => {
        console.log(err)
      },
    )
  }

  getTypes() {
    this.shopService.getTypes().subscribe(
      (res) => {
        this.types = [{ id: 0, name: 'All' }, ...res]
      },
      (erro) => {
        console.log(erro)
      },
      () => console.log('Completed'),
    )
  }

  onBrandSelected(brandId: number) {
    this.shopParams.brandId = brandId
    this.shopParams.pageNumber = 1
    this.getProducts()
  }

  onTypeSelected(typeId: number) {
    this.shopParams.typeId = typeId
    this.shopParams.pageNumber = 1
    this.getProducts()
  }

  onSortSelected(sort: string) {
    this.shopParams.sort = sort
    this.getProducts()
  }

  onPageChanged(event: any) {
    if (this.shopParams.pageNumber !== event) {
      this.shopParams.pageNumber = event
      this.getProducts()
    }
  }

  onSearch() {
    this.shopParams.search = this.searchTerm.nativeElement.value
    this.getProducts()
  }

  onReset() {
    this.searchTerm.nativeElement.value = ''
    this.shopParams = new ShopParams()
    this.getProducts()
  }
}
