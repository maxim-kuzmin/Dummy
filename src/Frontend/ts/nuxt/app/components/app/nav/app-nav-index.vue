<script setup lang="ts">
  import { useAppNavIndexComponentStore } from '~/utils/domain/app/components/nav/index/store/app-nav-index-component-store.composable'
  import { useAppNavIndexComponent } from '~/utils/domain/app/components/nav/index/app-nav-index-component.composable'
  import type { AppNavItemsComponentInput } from '~/utils/domain/app/components/nav/items/app-nav-items-component.types'

  useAppNavIndexComponent()

  const { items } = useAppNavIndexComponentStore()

  const itemsComponentInput = {
    items,
  } as AppNavItemsComponentInput
</script>

<template>
  <nav class="app-nav">
    <AppNavItems v-bind="itemsComponentInput" />
  </nav>
</template>
