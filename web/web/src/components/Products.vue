<template>
  <div class="products-container">
    <b-card
      v-for="item in items"
      :key="item.id"
      :title="item.name"
      :img-src="item.imageUrl"
      img-top
      tag="article"
      style="max-width: 20rem"
      class="mb-2 my-products"
    >
      <b-card-text>
        {{ item.name }}
      </b-card-text>

      <b-card-text style="font-weight: bold; font-size: 20px">
        R$ {{ item.price.toFixed(2) }}
      </b-card-text>

      <b-button :href="item.url" variant="primary">Ir a Web</b-button>
    </b-card>
  </div>
</template>

<style>
.products-container {
  display: flex;
  flex-wrap: wrap;
  max-width: 100%;
}

.my-products {
  width: 300px;
  margin: 10px;
}
</style>

<script type="js">
  import axios from "axios";
  import {bus} from "../main";


  export default {
    name: 'MyCard',
    data() {
      return {
        items: [],
        filterText:'',
        originalItems:[],
      };
    },

    created() {
      const vm = this;
      bus.$on('loadProducts', (category) => {
      vm.getProducts(category);
    });

    bus.$on("searchTerm", (searchTerm) =>{
      vm.filterText = searchTerm;
    });
    },

methods: {
  getProducts(category) {
    axios.get(`https://localhost:44369/Buscape/products/?categoria=${category}&page=1`)
      .then(data => { this.items = data.data; this.originalItems=data.data});
  },

  filterProducts(){
    if(this.filterText ===""){
      return this.items;
    }
    const searchTerm = this.filterText.toLowerCase();
    return this.items.filter(item =>{
      return(
        item.name?.toLowerCase().includes(searchTerm)||
        item.category?.toLowerCase().includes(searchTerm)
      );
    });
  },

},

  watch:{
    filterText: function(val) {
      if(val)
      this.items = this.filterProducts();
      else
      this.items = this.originalItems;
    }
  }
};
</script>
