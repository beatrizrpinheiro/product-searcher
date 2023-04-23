<template>
    <div class="products-container">
      <b-card v-for="item in items" :key="item.id"
        :title="item.name"
        :img-src="item.imageUrl"
        img-top
        tag="article"
        style="max-width: 20rem;"
        class="mb-2 my-products"
      >
        <b-card-text>
          {{ item.name }}
        </b-card-text>
  
        <b-button :href="item.url" variant="primary">Ir a Web</b-button>
      </b-card>
    </div>
  </template>

  <style>
  .products-container{
    display: flex;
  flex-wrap: wrap;
  max-width: 100%;
  }

  .my-products{
    width: 300px;
  margin: 10px;
  }

  </style>
  
  <script type="js">
  import axios from "axios";

  export default {
    name: 'MyCard',
    data() {
      return {
        items: []   
      }
    },

    mounted(){
        axios.get('https://localhost:44369/Buscape/products/?categoria=geladeira&page=1')
        .then(data => { this.items = data.data});

    }
}
  </script>
  