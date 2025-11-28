using AutoMapper;
using ECommerce.Business.Abstract;
using ECommerce.Business.FluentValidation.Products;
using ECommerce.Business.Response;
using ECommerce.Core;
using ECommerce.Core.Response;
using ECommerce.DataAccess.Abstract;
using ECommerce.Entity;

namespace ECommerce.Business.ConCreate;

public class ProductManager:IProductService
{
    private readonly IProductRepository _productRepository;
    private readonly IMapper _mapper;

    public ProductManager(IProductRepository productRepository, IMapper mapper)
    {
        _productRepository = productRepository;
        _mapper = mapper;
    }

    public async Task<ResponseObject<ProductDto>> GetByIdAsync(int productId)
    {
        ResponseObject<ProductDto> returnedObject = new ResponseObject<ProductDto>();
        returnedObject.Status = false;
        
        Product? product = await _productRepository.GetByIdAsync(productId);
        if (product != null)
        {
            returnedObject.Status = true;
            returnedObject.Entity = _mapper.Map<ProductDto>(product);
        }
        
        return returnedObject;
    }

    public async Task<ResponseObject<ProductDto>> AddAsync(ProductCreateDto productCreateDto)
    {
        ResponseObject<ProductDto> returnedObject = new ResponseObject<ProductDto>();
        ValidatorResponse response = Utility.Validator(productCreateDto, new ProductCreateDtoValidation());
        if (!response.IsValid)
        {
            returnedObject.Status = false;
            returnedObject.Errors = response.messages.Select(err => err.ErrorMessage).ToList();
            return returnedObject;
        }
        
        Product product = _mapper.Map<Product>(productCreateDto);
        var entity = await _productRepository.AddAsync(product);
        int savedCount = await _productRepository.SaveChangesAsync();
        if (savedCount > 0)
        {
            returnedObject.Status = true;
            returnedObject.Entity = _mapper.Map<ProductDto>(entity);
        }

        return returnedObject;
    }
    
    public async Task<ResponseObject<ProductDto>> UpdateAsync(int id, int stock)
    {
        ResponseObject<ProductDto> returnedObject = new ResponseObject<ProductDto>();
        Product? product = await _productRepository.GetByIdAsync(id);
        if (product == null)
        {
            returnedObject.Status = false;
            returnedObject.Message = Messages.ProductNotFound;
            return returnedObject;
        }
        product.Stock = stock;
        
        Product entity = _productRepository.Update(product);
        int savedCount = await _productRepository.SaveChangesAsync();
        if (savedCount > 0)
        {
            returnedObject.Status = true;
            returnedObject.Entity = _mapper.Map<ProductDto>(entity);
        }
        return returnedObject;
    }
}