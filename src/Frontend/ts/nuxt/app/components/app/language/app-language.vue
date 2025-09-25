<script setup lang="ts">
  import { useAppLanguageComponentStore } from '~/utils/domain/app/components/language/store/app-language-component-store.composable'
  import { useAppLanguageComponent } from '~/utils/domain/app/components/language/app-language-component.composable'

  useAppLanguageComponent()

  const { items, menuStyle, title } = useAppLanguageComponentStore()
</script>

<template>
  <nav class="app-language">
    <button ref="button" type="button">{{ title }}</button>
    <ul ref="menu" :style="menuStyle">
      <li
        v-for="item in items"
        :key="item.code"
        :data-selected="item.selected || null"
      >
        <NuxtLink :to="item.url">{{ item.name }}</NuxtLink>
      </li>
    </ul>
  </nav>
</template>
