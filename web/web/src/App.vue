<template>
  <div id="app">
  <b-navbar toggleable="lg" type="dark" variant="info">
    <b-navbar-brand href="#">ProductSeacher</b-navbar-brand>
    <b-navbar-toggle target="nav-collapse"></b-navbar-toggle>
    <b-collapse id="nav-collapse" is-nav>
      <b-navbar-nav>
       <b-nav-item-dropdown text="Web" right>
          <b-dropdown-item href="#">Todas</b-dropdown-item>
          <b-dropdown-item href="#">Mercado Livre</b-dropdown-item>
          <b-dropdown-item href="#">Buscapé</b-dropdown-item>
        </b-nav-item-dropdown>

       <b-nav-item-dropdown text="Categorias" right>
         <b-dropdown-item @click="getProducts('Geladeira')">Geladeira</b-dropdown-item>
         <b-dropdown-item @click="getProducts('TV')">TV</b-dropdown-item>
         <b-dropdown-item @click="getProducts('Celular')">Celular</b-dropdown-item>
       </b-nav-item-dropdown>
      </b-navbar-nav>

      <!-- Right aligned nav items -->
      <b-navbar-nav class="ml-auto">
        <b-nav-form>
          <b-form-input size="sm" class="mr-sm-2" placeholder="Search"></b-form-input>
          <b-button size="sm" class="my-2 my-sm-0" type="submit">Search</b-button>
        </b-nav-form>
      </b-navbar-nav>
    </b-collapse>
  </b-navbar>

  <Products/>
</div>
</template>

<style lang="scss">
</style>

<script>
import Products from './components/Products.vue';
import {bus} from "./main";

export default{
  components:{
    Products
  },

  methods:{
    getProducts(category){
bus.$emit("loadProducts", category);
    }
  }
}
</script>
